import 'package:flutter/material.dart';
import 'package:IB210370/modules/shared/theme/utils.dart';
import 'package:IB210370/modules/shared/widgets/button.dart';
import 'package:IB210370/modules/wallet/models/voucher_options_buy_arguments.dart';
import 'package:IB210370/modules/wallet/wallet_options_buy.screen.dart';
import 'package:IB210370/modules/wallet/widgets/voucher_option_item.dart';

class VoucherOption {
  int? id;
  String? title;
  double? amount;

  VoucherOption({
    this.id,
    this.title,
    this.amount,
  });
}

class VoucherOptionChoose extends StatefulWidget {
  const VoucherOptionChoose({
    super.key,
  });

  @override
  VoucherOptionChooseState createState() => VoucherOptionChooseState();
}

class VoucherOptionChooseState extends State<VoucherOptionChoose> {
  List<VoucherOption> options = [
    VoucherOption(
      id: 0,
      title: "Buy 15.00 credits",
      amount: 15.00,
    ),
    VoucherOption(
      id: 1,
      title: "Buy 30.00 credits",
      amount: 30.00,
    ),
    VoucherOption(
      id: 2,
      title: "Buy 50.00 credits",
      amount: 50.00,
    ),
  ];

  VoucherOption? selectedItem;

  void setSelectedIndex(int id) {
    if (id == selectedItem?.id) return;

    setState(() {
      selectedItem = options[id];
    });
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      children: <Widget>[
        ListView.builder(
          scrollDirection: Axis.vertical,
          shrinkWrap: true,
          itemCount: options.length,
          itemBuilder: (BuildContext context, int position) {
            return VoucherOptionItem(
              title: options[position].title,
              id: options[position].id,
              amount: options[position].amount,
              selected: selectedItem?.id == position,
              press: (id) => setSelectedIndex(id),
            );
          },
        ),
        SizedBox(
          height: getProportionateScreenHeight(40),
        ),
        Button(
          text: "Continue",
          disabled: selectedItem == null,
          press: () =>
              // Navigate to stripe form
              Navigator.pushNamed(
            context,
            WalletOptionsBuyScreen.routeName,
            arguments: VoucherOptionsBuyArguments(item: selectedItem),
          ),
        ),
      ],
    );
  }
}
