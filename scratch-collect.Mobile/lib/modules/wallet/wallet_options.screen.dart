import 'package:flutter/material.dart';
import 'package:IB210370/modules/shared/enums.dart';
import 'package:IB210370/modules/shared/theme/size_config.dart';
import 'package:IB210370/modules/shared/theme/utils.dart';
import 'package:IB210370/modules/shared/widgets/navigation.dart';
import 'package:IB210370/modules/wallet/widgets/voucher_option_choose.dart';
import 'package:IB210370/modules/wallet/widgets/voucher_options_intro.dart';

class WalletOptionsScreen extends StatefulWidget {
  const WalletOptionsScreen({Key? key}) : super(key: key);

  static String routeName = "/wallet/voucher/options";

  @override
  WalletOptionsScreenState createState() => WalletOptionsScreenState();
}

class WalletOptionsScreenState extends State<WalletOptionsScreen> {
  @override
  Widget build(BuildContext context) {
    SizeConfig().init(context);

    return Scaffold(
      appBar: AppBar(
        title: const Text(
          "Buy voucher options",
        ),
      ),
      bottomNavigationBar: const BottomNavigation(
        selectedMenu: MenuState.profile,
      ),
      body: SafeArea(
        child: SizedBox(
          width: double.infinity,
          child: Padding(
            padding: EdgeInsets.symmetric(
              horizontal: getProportionateScreenWidth(20),
            ),
            child: SingleChildScrollView(
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: <Widget>[
                  SizedBox(height: getProportionateScreenHeight(40)),
                  const VoucherOptionsIntro(),
                  SizedBox(height: getProportionateScreenHeight(40)),
                  const VoucherOptionChoose(),
                ],
              ),
            ),
          ),
        ),
      ),
    );
  }
}
