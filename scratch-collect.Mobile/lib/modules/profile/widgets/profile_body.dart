import 'dart:convert';

import 'package:flutter/widgets.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:scratch_collect/modules/auth/login.screen.dart';
import 'package:scratch_collect/modules/auth/services/auth.service.dart';
import 'package:scratch_collect/modules/profile/change_password.screen.dart';
import 'package:scratch_collect/modules/profile/profile_edit.screen.dart';
import 'package:scratch_collect/modules/profile/models/profile_request.model.dart';
import 'package:scratch_collect/modules/profile/services/profile.service.dart';
import 'package:scratch_collect/modules/profile/widgets/profile_body_loading.dart';
import 'package:scratch_collect/modules/profile/widgets/profile_menu.dart';
import 'package:scratch_collect/modules/profile/widgets/profile_pic.dart';
import 'package:scratch_collect/modules/shared/theme/colors.dart';
import 'package:scratch_collect/modules/shared/theme/size_config.dart';
import 'package:scratch_collect/modules/shared/theme/styles.dart';
import 'package:scratch_collect/modules/shared/theme/utils.dart';
import 'package:scratch_collect/modules/shared/utils/storage.dart';
import 'package:scratch_collect/modules/shared/widgets/no_data.dart';
import 'package:scratch_collect/modules/shared/widgets/snackbar.dart';
import 'package:skeletons/skeletons.dart';

class ProfileBody extends StatefulWidget {
  const ProfileBody({Key? key}) : super(key: key);

  @override
  ProfileBodyState createState() => ProfileBodyState();
}

class ProfileBodyState extends State<ProfileBody> {
  late Future<dynamic> userProfile;

  @override
  void initState() {
    super.initState();

    userProfile = loadProfileData();
  }

  // Custom handlers
  Future<void> loadProfileData() async {
    var persisted = await AuthService().getPersistedUser();
    var request = ProfileRequest(id: persisted.id);

    if (!mounted) return;

    try {
      var user = await ProfileService().getUserProfile(request);

      if (!mounted) return;

      // TODO: Persist to storage ?
      Snackbar.showSuccess(context, "Profile loaded!");
    } on Exception catch (e) {
      Snackbar.showError(context, "Someting went wrong!");
    }
  }

  @override
  Widget build(BuildContext context) {
    SizeConfig().init(context);

    return FutureBuilder(
      future: userProfile,
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
                  const ProfilePic(),
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
