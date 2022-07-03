import 'package:flutter/widgets.dart';
import 'package:IB210370/modules/shared/theme/utils.dart';
import 'package:IB210370/modules/shared/widgets/button.dart';
import 'package:IB210370/modules/wallet/wallet_options.screen.dart';

class PurchaseVoucher extends StatelessWidget {
  const PurchaseVoucher({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        Text(
          "Or purchase voucher options right now",
          style: TextStyle(
            fontSize: getProportionateScreenWidth(16),
          ),
        ),
        SizedBox(height: getProportionateScreenHeight(15)),
        Button(
          variant: ButtonVariants.secondary,
          text: "Purchase",
          press: () {
            Navigator.pushNamed(context, WalletOptionsScreen.routeName);
          },
        )
      ],
    );
  }
}
