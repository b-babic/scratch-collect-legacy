import 'package:flutter/widgets.dart';
import 'package:IB210370/modules/shared/theme/colors.dart';
import 'package:IB210370/modules/shared/theme/utils.dart';
import 'package:flutter_svg/flutter_svg.dart';

class RatingInfo extends StatelessWidget {
  const RatingInfo({
    Key? key,
    required this.rating,
  }) : super(key: key);

  final double rating;

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: const EdgeInsets.symmetric(
        vertical: 5,
      ),
      decoration: BoxDecoration(
        color: whiteColor,
        borderRadius: BorderRadius.circular(14),
      ),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.start,
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Text(
            "$rating",
            style: const TextStyle(
              fontSize: 14,
              fontWeight: FontWeight.w600,
            ),
          ),
          SizedBox(width: getProportionateScreenWidth(5)),
          SvgPicture.asset(
            "lib/modules/shared/assets/icons/star.svg",
            width: getProportionateScreenWidth(32),
            height: getProportionateScreenHeight(32),
          ),
        ],
      ),
    );
  }
}
