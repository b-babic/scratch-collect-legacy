import 'package:flutter/material.dart';
import 'package:IB210370/modules/profile/widgets/profile_body.dart';
import 'package:IB210370/modules/shared/enums.dart';
import 'package:IB210370/modules/shared/widgets/navigation.dart';

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
