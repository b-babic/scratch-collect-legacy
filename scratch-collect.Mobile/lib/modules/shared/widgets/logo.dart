import 'package:flutter/widgets.dart';

class LogoWidget extends StatelessWidget {
  const LogoWidget({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return SizedBox(
        height: 100,
        width: 100,
        child: Image.asset(
          'lib/modules/shared/assets/logo.png',
          fit: BoxFit.contain,
        ));
  }
}
