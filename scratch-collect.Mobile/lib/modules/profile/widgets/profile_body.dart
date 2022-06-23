// ignore_for_file: use_build_context_synchronously

import 'package:flutter/widgets.dart';
import 'package:scratch_collect/modules/auth/login.screen.dart';
import 'package:scratch_collect/modules/auth/services/auth.service.dart';
import 'package:scratch_collect/modules/profile/change_password.screen.dart';
import 'package:scratch_collect/modules/profile/models/profile.model.dart';
import 'package:scratch_collect/modules/profile/profile_edit.screen.dart';
import 'package:scratch_collect/modules/profile/models/profile_request.model.dart';
import 'package:scratch_collect/modules/profile/services/profile.service.dart';
import 'package:scratch_collect/modules/profile/widgets/profile_body_loading.dart';
import 'package:scratch_collect/modules/profile/widgets/profile_menu.dart';
import 'package:scratch_collect/modules/profile/widgets/profile_pic.dart';
import 'package:scratch_collect/modules/shared/theme/size_config.dart';
import 'package:scratch_collect/modules/shared/widgets/no_data.dart';
import 'package:scratch_collect/modules/shared/widgets/snackbar.dart';

class ProfileBody extends StatefulWidget {
  const ProfileBody({Key? key}) : super(key: key);

  @override
  ProfileBodyState createState() => ProfileBodyState();
}

class ProfileBodyState extends State<ProfileBody> {
  late Future<dynamic> profileFuture;
  late final ProfileResponse userProfile;

  @override
  void initState() {
    super.initState();

    profileFuture = loadProfileData();
  }

  // Custom handlers
  Future<void> loadProfileData() async {
    var persisted = await AuthService().getPersistedUser();
    var request = ProfileRequest(id: persisted.id);

    try {
      var user = await ProfileService().getUserProfile(request);

      setState(() {
        userProfile = user;
      });

      Snackbar.showSuccess(context, "Profile loaded!");
      // TODO: Persist to storage ?
    } on Exception catch (_) {
      Snackbar.showError(context, "Someting went wrong!");
    }
  }

  @override
  Widget build(BuildContext context) {
    SizeConfig().init(context);

    return FutureBuilder(
      future: profileFuture,
      builder: (context, snapshot) {
        if (snapshot.hasError) {
          return const NoData();
        } else if (snapshot.connectionState != ConnectionState.done) {
          return const ProfileBodyLoading();
        } else {
          return SingleChildScrollView(
              padding: const EdgeInsets.symmetric(vertical: 40),
              child: Column(
                children: <Widget>[
                  ProfilePic(
                    profilePhoto: userProfile.userPhoto,
                  ),
                  const SizedBox(height: 30),
                  ProfileMenu(
                      text: "Edit Profile",
                      icon: "lib/modules/shared/assets/icons/user.svg",
                      press: () => Navigator.pushNamed(
                          context, ProfileEditScreen.routeName)),
                  ProfileMenu(
                      text: "Change Password",
                      icon: "lib/modules/shared/assets/icons/lock.svg",
                      press: () => Navigator.pushNamed(
                          context, ChangePasswordScreen.routeName)),
                  ProfileMenu(
                    text: "Log Out",
                    icon: "lib/modules/shared/assets/icons/logout.svg",
                    press: () async {
                      await AuthService().logout();

                      if (!mounted) return;

                      Snackbar.showSuccess(context, "Successfully logged out");
                      Navigator.pushNamed(context, LoginScreen.routeName);
                    },
                  ),
                ],
              ));
        }
      },
    );
  }
}
