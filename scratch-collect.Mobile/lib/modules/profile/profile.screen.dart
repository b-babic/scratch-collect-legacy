import 'package:flutter/material.dart';
import 'package:scratch_collect/modules/profile/widgets/profile_body.dart';
import 'package:scratch_collect/modules/shared/enums.dart';
import 'package:scratch_collect/modules/shared/widgets/navigation.dart';

class ProfileScreen extends StatefulWidget {
  const ProfileScreen({Key? key}) : super(key: key);

  static String routeName = "/profile";

  @override
  ProfileScreenState createState() => ProfileScreenState();
}

class ProfileScreenState extends State<ProfileScreen> {
  @override
  Widget build(BuildContext context) {
    return const Scaffold(
        bottomNavigationBar: BottomNavigation(selectedMenu: MenuState.profile),
        body: ProfileBody());
  }
}
