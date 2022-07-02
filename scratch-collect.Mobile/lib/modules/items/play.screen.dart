import 'package:flutter/material.dart';
import 'package:scratch_collect/modules/items/widgets/play_body.dart';
import 'package:scratch_collect/modules/shared/enums.dart';
import 'package:scratch_collect/modules/shared/widgets/navigation.dart';

class PlayScreen extends StatefulWidget {
  const PlayScreen({Key? key}) : super(key: key);

  static String routeName = "/items/play";

  @override
  PlayScreenState createState() => PlayScreenState();
}

class PlayScreenState extends State<PlayScreen> {
  @override
  Widget build(BuildContext context) {
    return const Scaffold(
      bottomNavigationBar: BottomNavigation(selectedMenu: MenuState.items),
      body: PlayBody(),
    );
  }
}
