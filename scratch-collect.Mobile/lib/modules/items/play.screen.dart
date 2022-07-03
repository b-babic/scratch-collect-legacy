import 'package:flutter/material.dart';
import 'package:scratch_collect/modules/items/items.screen.dart';
import 'package:scratch_collect/modules/items/models/play_screen_arguments.model.dart';
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
    final PlayScreenArguments args =
        ModalRoute.of(context)!.settings.arguments as PlayScreenArguments;

    return Scaffold(
      appBar: AppBar(
        leading: BackButton(
          onPressed: () {
            Navigator.pushReplacement(
              context,
              MaterialPageRoute(
                builder: (context) => const ItemsScreen(),
              ),
            );
          },
        ),
        title: const Text(
          "Scratch & Collect",
        ),
      ),
      bottomNavigationBar:
          const BottomNavigation(selectedMenu: MenuState.items),
      body: PlayBody(args: args),
    );
  }
}
