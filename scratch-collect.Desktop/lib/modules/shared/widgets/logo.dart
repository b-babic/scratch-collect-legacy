import 'package:flutter/widgets.dart';
import 'package:ib210370_desktop/modules/shared/theme/utils.dart';

class LogoWidget extends StatelessWidget {
  const LogoWidget({super.key});

  @override
  Widget build(BuildContext context) {
    return SizedBox(
        height: getProportionateScreenHeight(100),
        width: getProportionateScreenWidth(100),
        child: Image.asset(
          'lib/modules/shared/assets/logo.png',
          fit: BoxFit.contain,
        ));
  }
}
