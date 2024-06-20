import 'package:flutter/widgets.dart';
import 'package:flutter_svg/svg.dart';
import 'package:ib210370_desktop/modules/shared/theme/size_config.dart';
import 'package:ib210370_desktop/modules/shared/theme/utils.dart';

class FormError extends StatelessWidget {
  const FormError({
    super.key,
    required this.errors,
  });

  final List<String?> errors;

  @override
  Widget build(BuildContext context) {
    SizeConfig().init(context);

    return Column(
      children: List.generate(
        errors.length,
        (index) => formErrorText(error: errors[index]!),
      ),
    );
  }

  Row formErrorText({required String error}) {
    return Row(
      children: [
        SvgPicture.asset("lib/modules/shared/assets/icons/error.svg",
            height: getProportionateScreenWidth(14),
            width: getProportionateScreenWidth(14),
            semanticsLabel: 'A red error sign'),
        SizedBox(
          width: getProportionateScreenWidth(10),
        ),
        Text(error),
      ],
    );
  }
}
