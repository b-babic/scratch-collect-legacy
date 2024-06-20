import 'package:flutter/material.dart';
import 'package:IB210370/modules/shared/theme/colors.dart';
import 'package:IB210370/modules/shared/theme/utils.dart';

class VoucherOptionItem extends StatelessWidget {
  final int? id;
  final String? title;
  final double? amount;
  final bool selected;
  final Function? press;

  const VoucherOptionItem({
    super.key,
    required this.id,
    required this.title,
    required this.amount,
    required this.press,
    this.selected = false,
  });

  @override
  Widget build(BuildContext context) {
    return InkWell(
      onTap: () => press!(id),
      child: Card(
        shape: selected
            ? const RoundedRectangleBorder(
                side: BorderSide(
                  color: primaryColor,
                ),
              )
            : null,
        elevation: selected ? 5 : 3,
        child: Padding(
          padding: EdgeInsets.all(getProportionateScreenHeight(20)),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            mainAxisAlignment: MainAxisAlignment.spaceAround,
            children: <Widget>[
              Text(
                "${amount.toString()}\$",
                style: TextStyle(
                  fontWeight: FontWeight.bold,
                  fontSize: getProportionateScreenWidth(18),
                ),
              ),
              SizedBox(
                height: getProportionateScreenHeight(20),
              ),
              Text(
                title!,
                style: TextStyle(
                  color: secondaryColor,
                  fontWeight: FontWeight.normal,
                  fontSize: getProportionateScreenWidth(16),
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
