// ignore_for_file: use_build_context_synchronously

import 'dart:convert';

import 'package:IB210370/modules/shared/theme/utils.dart';
import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:IB210370/modules/auth/login.screen.dart';
import 'package:IB210370/modules/auth/services/auth.service.dart';
import 'package:IB210370/modules/profile/change_password.screen.dart';
import 'package:IB210370/modules/profile/models/edit_password_arguments.dart';
import 'package:IB210370/modules/profile/models/edit_profile_arguments.model.dart';
import 'package:IB210370/modules/profile/models/profile.model.dart';
import 'package:IB210370/modules/profile/profile_edit.screen.dart';
import 'package:IB210370/modules/profile/models/profile_request.model.dart';
import 'package:IB210370/modules/profile/services/profile.service.dart';
import 'package:IB210370/modules/profile/widgets/profile_balance.dart';
import 'package:IB210370/modules/profile/widgets/profile_body_loading.dart';
import 'package:IB210370/modules/profile/widgets/profile_info.dart';
import 'package:IB210370/modules/profile/widgets/profile_menu.dart';
import 'package:IB210370/modules/profile/widgets/profile_pic.dart';
import 'package:IB210370/modules/shared/theme/size_config.dart';
import 'package:IB210370/modules/shared/utils/secure_storage.dart';
import 'package:IB210370/modules/shared/widgets/error_data.dart';
import 'package:IB210370/modules/shared/widgets/snackbar.dart';
import 'package:IB210370/modules/wallet/wallet_voucher.screen.dart';

class ProfileBody extends StatefulWidget {
  const ProfileBody({super.key});

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

      await SecureStorage().write("profile", json.encode(user.toJson()));
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
          return const ErrorData();
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
                SizedBox(height: getProportionateScreenHeight(15)),
                ProfileBalance(balance: "${userProfile.wallet?.balance}\$"),
                SizedBox(height: getProportionateScreenHeight(15)),
                ProfileMenu(
                  text: "Wallet - payments",
                  icon: "lib/modules/shared/assets/icons/dollar.svg",
                  press: () => Navigator.pushNamed(
                      context, WalletVoucherScreen.routeName),
                ),
                SizedBox(height: getProportionateScreenHeight(40)),
                ProfileInfo(
                  name: (userProfile.firstName!.isNotEmpty &&
                          userProfile.lastName!.isNotEmpty)
                      ? "${userProfile.firstName} ${userProfile.lastName}"
                      : "",
                  username: "${userProfile.username}",
                ),
                SizedBox(height: getProportionateScreenHeight(20)),
                ProfileMenu(
                  text: "Edit Profile",
                  icon: "lib/modules/shared/assets/icons/user.svg",
                  press: () => Navigator.pushNamed(
                    context,
                    ProfileEditScreen.routeName,
                    arguments: EditProfileArguments(
                      userProfile.id,
                      userProfile.email,
                      userProfile.username,
                      userProfile.firstName,
                      userProfile.lastName,
                      userProfile.address,
                    ),
                  ),
                ),
                ProfileMenu(
                  text: "Change Password",
                  icon: "lib/modules/shared/assets/icons/lock.svg",
                  press: () => Navigator.pushNamed(
                    context,
                    ChangePasswordScreen.routeName,
                    arguments: EditPasswordArguments(userProfile.id),
                  ),
                ),
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
            ),
          );
        }
      },
    );
  }
}
