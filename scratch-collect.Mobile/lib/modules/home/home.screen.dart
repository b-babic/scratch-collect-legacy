import 'package:flutter/material.dart';
import 'package:scratch_collect/modules/shared/enums.dart';
import 'package:scratch_collect/modules/shared/widgets/navigation.dart';

class HomeScreen extends StatefulWidget {
  const HomeScreen({Key? key}) : super(key: key);

  static String routeName = "/home_screen";

  @override
  HomeScreenState createState() => HomeScreenState();
}

class HomeScreenState extends State<HomeScreen> {
  @override
  Widget build(BuildContext context) {
    return const Scaffold(
        bottomNavigationBar: BottomNavigation(selectedMenu: MenuState.offers),
        body: Center(child: Text("Body")));
  }
}
