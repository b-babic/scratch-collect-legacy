import 'package:flutter/widgets.dart';
import 'package:IB210370/modules/shared/theme/colors.dart';
import 'package:IB210370/modules/shared/theme/utils.dart';

class NoData extends StatelessWidget {
  const NoData({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Center(
      heightFactor: 10,
      child: Text(
        "No results found.",
        style: TextStyle(
          fontSize: getProportionateScreenWidth(18),
          color: secondaryColor,
        ),
      ),
    );
  }
}
