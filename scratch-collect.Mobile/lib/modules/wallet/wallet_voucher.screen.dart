import 'package:flutter/material.dart';
import 'package:IB210370/modules/profile/profile.screen.dart';
import 'package:IB210370/modules/wallet/widgets/purchase_voucher.dart';
import 'package:IB210370/modules/wallet/widgets/voucher_intro.dart';
import 'package:IB210370/modules/shared/enums.dart';
import 'package:IB210370/modules/shared/theme/size_config.dart';
import 'package:IB210370/modules/shared/theme/utils.dart';
import 'package:IB210370/modules/shared/widgets/navigation.dart';
import 'package:IB210370/modules/wallet/widgets/voucher_use_form.dart';

class WalletVoucherScreen extends StatefulWidget {
  const WalletVoucherScreen({super.key});

  static String routeName = "/wallet/voucher/use";

  @override
  WalletVoucherScreenState createState() => WalletVoucherScreenState();
}

class WalletVoucherScreenState extends State<WalletVoucherScreen> {
  @override
  Widget build(BuildContext context) {
    SizeConfig().init(context);

    return Scaffold(
      appBar: AppBar(
        leading: BackButton(
          onPressed: () {
            Navigator.pushReplacement(
              context,
              MaterialPageRoute(
                builder: (context) => const ProfileScreen(),
              ),
            );
          },
        ),
        title: const Text(
          "Use Voucher",
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
                  const VoucherIntro(),
                  SizedBox(height: getProportionateScreenHeight(40)),
                  const VoucherUseForm(),
                  SizedBox(height: getProportionateScreenHeight(120)),
                  const PurchaseVoucher(),
                ],
              ),
            ),
          ),
        ),
      ),
    );
  }
}
