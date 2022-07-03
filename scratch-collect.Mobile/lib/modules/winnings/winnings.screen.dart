import 'package:flutter/material.dart';
import 'package:IB210370/modules/shared/enums.dart';
import 'package:IB210370/modules/shared/widgets/navigation.dart';
import 'package:IB210370/modules/winnings/widgets/winnings_body.dart';

class WinningsScreen extends StatefulWidget {
  const WinningsScreen({Key? key}) : super(key: key);

  static String routeName = "/winnings";

  @override
  WinningsScreenState createState() => WinningsScreenState();
}

class WinningsScreenState extends State<WinningsScreen> {
  @override
  Widget build(BuildContext context) {
    return const Scaffold(
      bottomNavigationBar: BottomNavigation(selectedMenu: MenuState.winnings),
      body: WinningsBody(),
    );
  }
}
