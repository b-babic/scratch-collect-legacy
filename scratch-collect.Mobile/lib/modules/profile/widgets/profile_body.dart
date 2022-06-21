import 'package:flutter/widgets.dart';
import 'package:scratch_collect/modules/profile/widgets/profile_menu.dart';
import 'package:scratch_collect/modules/profile/widgets/profile_pic.dart';

class ProfileBody extends StatefulWidget {
  const ProfileBody({Key? key}) : super(key: key);

  @override
  ProfileBodyState createState() => ProfileBodyState();
}

class ProfileBodyState extends State<ProfileBody> {
  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
        padding: const EdgeInsets.symmetric(vertical: 40),
        child: Column(
          children: <Widget>[
            const ProfilePic(),
            const SizedBox(height: 30),
            const ProfileMenu(
              text: "My Account",
              icon: "lib/modules/shared/assets/icons/user.svg",
              // press: () async => {},
            ),
            ProfileMenu(
              text: "Log Out",
              icon: "lib/modules/shared/assets/icons/logout.svg",
              press: () => print("Log out called"),
            ),
          ],
        ));
  }
}
