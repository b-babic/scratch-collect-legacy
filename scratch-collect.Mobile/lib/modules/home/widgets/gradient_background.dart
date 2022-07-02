import 'package:flutter/widgets.dart';
import 'package:scratch_collect/modules/home/models/category.model.dart';
import 'package:scratch_collect/modules/shared/utils/colors.dart';

class GradientBackground extends StatelessWidget {
  final Category? category;

  const GradientBackground({
    Key? key,
    required this.category,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return AspectRatio(
      aspectRatio: 2,
      child: Hero(
        tag: category?.id.toString() ?? "offer-details-no-item",
        child: Container(
          decoration: BoxDecoration(
            gradient: LinearGradient(
              begin: Alignment.topRight,
              end: Alignment.bottomLeft,
              // Add one stop for each color. Stops should increase from 0 to 1
              stops: const [0.1, 0.9],
              colors: [
                colorFromHex(category?.gradientStart ?? ""),
                colorFromHex(category?.gradientStop ?? ""),
              ],
            ),
          ),
        ),
      ),
    );
  }
}