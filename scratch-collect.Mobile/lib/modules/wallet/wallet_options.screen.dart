import 'package:flutter/material.dart';
import 'package:scratch_collect/modules/shared/enums.dart';
import 'package:scratch_collect/modules/shared/widgets/navigation.dart';

class WalletOptionsScreen extends StatefulWidget {
  const WalletOptionsScreen({Key? key}) : super(key: key);

  static String routeName = "/wallet/voucher/buy";

  @override
  WalletOptionsScreenState createState() => WalletOptionsScreenState();
}

class WalletOptionsScreenState extends State<WalletOptionsScreen> {
  @override
  Widget build(BuildContext context) {
    return const Scaffold(
      bottomNavigationBar: BottomNavigation(
        selectedMenu: MenuState.profile,
      ),
      body: Center(
        child: Text("Payment options"),
      ),
    );
  }
}
