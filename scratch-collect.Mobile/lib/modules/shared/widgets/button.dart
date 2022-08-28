import 'package:flutter/material.dart';
import 'package:IB210370/modules/shared/theme/colors.dart';
import 'package:IB210370/modules/shared/theme/utils.dart';

enum ButtonVariants { primary, secondary }

final buttonStyle = TextStyle(
  fontSize: getProportionateScreenWidth(18),
  color: whiteColor,
);

class Button extends StatelessWidget {
  const Button({
    Key? key,
    this.text,
    this.variant = ButtonVariants.primary,
    this.disabled = false,
    this.loading = false,
    this.press,
  }) : super(key: key);

  final ButtonVariants variant;
  final String? text;
  final bool disabled;
  final bool loading;
  final Function? press;

  Color _buildVariantBackgroundColor() {
    switch (variant) {
      case ButtonVariants.primary:
        return primaryColor;
      case ButtonVariants.secondary:
        return textColor;
      default:
        return primaryColor;
    }
  }

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      width: double.infinity,
      child: TextButton(
        style: TextButton.styleFrom(
          shape: RoundedRectangleBorder(
            borderRadius: BorderRadius.circular(10),
          ),
          padding: const EdgeInsets.all(15),
          primary: disabled ? tertiaryColor : _buildVariantBackgroundColor(),
          backgroundColor:
              disabled ? tertiaryColor : _buildVariantBackgroundColor(),
        ),
        onPressed: !disabled ? press as void Function()? : null,
        child: Row(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            if (loading)
              SizedBox(
                height: getProportionateScreenHeight(28),
                width: getProportionateScreenWidth(22),
                child: const CircularProgressIndicator(
                  color: whiteColor,
                  strokeWidth: 2.0,
                ),
              ),
            if (loading)
              SizedBox(
                width: getProportionateScreenWidth(25),
              ),
            loading
                ? Text(
                    'Loading...',
                    style: buttonStyle,
                  )
                : Text(
                    text!,
                    style: buttonStyle,
                  ),
          ],
        ),
      ),
    );
  }
}
