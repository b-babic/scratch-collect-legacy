import 'package:flutter/material.dart';
import 'package:IB210370/modules/home/widgets/offers_body.dart';
import 'package:IB210370/modules/shared/enums.dart';
import 'package:IB210370/modules/shared/widgets/navigation.dart';

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
      body: OffersBody(),
    );
  }
}
