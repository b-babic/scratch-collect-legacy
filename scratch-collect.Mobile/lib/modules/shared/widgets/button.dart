import 'package:flutter/material.dart';
import 'package:IB210370/modules/shared/theme/colors.dart';
import 'package:IB210370/modules/shared/theme/utils.dart';

enum ButtonVariants { primary, secondary }

class Button extends StatelessWidget {
  const Button({
    Key? key,
    this.text,
    this.variant = ButtonVariants.primary,
    this.disabled = false,
    this.press,
  }) : super(key: key);

  final ButtonVariants variant;
  final String? text;
  final bool disabled;
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
      height: getProportionateScreenHeight(56),
      child: TextButton(
        style: TextButton.styleFrom(
          shape: RoundedRectangleBorder(
            borderRadius: BorderRadius.circular(10),
          ),
          primary: disabled ? tertiaryColor : _buildVariantBackgroundColor(),
          backgroundColor:
              disabled ? tertiaryColor : _buildVariantBackgroundColor(),
        ),
        onPressed: !disabled ? press as void Function()? : null,
        child: Text(
          text!,
          style: TextStyle(
            fontSize: getProportionateScreenWidth(18),
            color: whiteColor,
          ),
        ),
      ),
    );
  }
}
