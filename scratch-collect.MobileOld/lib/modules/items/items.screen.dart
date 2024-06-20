import 'package:flutter/material.dart';
import 'package:IB210370/modules/items/widgets/user_offers_body.dart';
import 'package:IB210370/modules/shared/enums.dart';
import 'package:IB210370/modules/shared/widgets/navigation.dart';

class ItemsScreen extends StatefulWidget {
  const ItemsScreen({super.key});

  static String routeName = "/items";

  @override
  ItemsScreenState createState() => ItemsScreenState();
}

class ItemsScreenState extends State<ItemsScreen> {
  @override
  Widget build(BuildContext context) {
    return const Scaffold(
      bottomNavigationBar: BottomNavigation(selectedMenu: MenuState.items),
      body: UserOffersBody(),
    );
  }
}
