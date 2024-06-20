import 'package:flutter/material.dart';
import 'package:IB210370/modules/shared/theme/styles.dart';
import 'package:IB210370/modules/shared/theme/utils.dart';
import 'package:IB210370/modules/wallet/models/voucher_options_buy_arguments.dart';
import 'package:IB210370/modules/wallet/widgets/buy_voucher_options_form.dart';

import '../shared/theme/size_config.dart';

class WalletOptionsBuyScreen extends StatelessWidget {
  const WalletOptionsBuyScreen({
    super.key,
  });

  static String routeName = "/wallet/voucher/options/buy";

  @override
  Widget build(BuildContext context) {
    // Arguments
    final args = ModalRoute.of(context)!.settings.arguments
        as VoucherOptionsBuyArguments;

    return Scaffold(
      appBar: AppBar(
        title: const Text("Add payment details"),
      ),
      body: SafeArea(
        child: SizedBox(
          width: double.infinity,
          child: Padding(
            padding: EdgeInsets.symmetric(
                horizontal: getProportionateScreenWidth(20)),
            child: SingleChildScrollView(
              child: Column(
                children: [
                  SizedBox(height: SizeConfig.screenHeight * 0.03),
                  Text("Top up ${args.item?.amount}\$", style: headingStyle),
                  const Text(
                    "Money will go directly to your wallet",
                    textAlign: TextAlign.center,
                  ),
                  SizedBox(height: SizeConfig.screenHeight * 0.06),
                  BuyVoucherOptionsForm(
                    initialValues: args,
                  ),
                  SizedBox(height: getProportionateScreenHeight(30)),
                ],
              ),
            ),
          ),
        ),
      ),
    );
  }
}
