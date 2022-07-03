import 'package:flutter/material.dart';
import 'package:scratch_collect/modules/shared/enums.dart';
import 'package:scratch_collect/modules/shared/widgets/navigation.dart';
import 'package:scratch_collect/modules/winnings/widgets/winnings_body.dart';

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
