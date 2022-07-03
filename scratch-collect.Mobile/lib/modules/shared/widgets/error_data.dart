import 'package:flutter/widgets.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:IB210370/modules/shared/theme/colors.dart';
import 'package:IB210370/modules/shared/theme/styles.dart';
import 'package:IB210370/modules/shared/theme/utils.dart';

class ErrorData extends StatelessWidget {
  const ErrorData({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Center(
        child: Column(mainAxisAlignment: MainAxisAlignment.center, children: [
      SvgPicture.asset(
        'lib/modules/shared/assets/icons/info.svg',
        height: getProportionateScreenHeight(80),
        width: getProportionateScreenWidth(80),
        color: primaryColor,
      ),
      Text(
        'Network data failed !',
        style: headingStyle,
      ),
      const Text('Please try again.')
    ]));
  }
}
