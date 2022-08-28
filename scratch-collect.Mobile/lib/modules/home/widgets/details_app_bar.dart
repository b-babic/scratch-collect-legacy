import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:IB210370/modules/home/home.screen.dart';
import 'package:IB210370/modules/shared/theme/colors.dart';
import 'package:IB210370/modules/shared/theme/utils.dart';

class DetailsAppBar extends StatelessWidget {
  final double rating;

  const DetailsAppBar({Key? key, required this.rating}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Padding(
        padding: EdgeInsets.symmetric(
          horizontal: getProportionateScreenWidth(10),
          vertical: getProportionateScreenWidth(10),
        ),
        child: Row(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          crossAxisAlignment: CrossAxisAlignment.center,
          children: [
            SizedBox(
              height: getProportionateScreenWidth(40),
              width: getProportionateScreenWidth(40),
              child: TextButton(
                style: TextButton.styleFrom(
                  shape: RoundedRectangleBorder(
                    borderRadius: BorderRadius.circular(60),
                  ),
                  primary: primaryColor,
                  backgroundColor: whiteColor,
                  padding: EdgeInsets.zero,
                ),
                onPressed: () {
                  Navigator.pushReplacement(
                    context,
                    MaterialPageRoute(
                      builder: (context) => const HomeScreen(),
                    ),
                  );
                },
                child: SizedBox(
                  width: getProportionateScreenWidth(20),
                  child: const Icon(Icons.arrow_back),
                ),
              ),
            ),
            const Spacer(),
            Container(
              padding: const EdgeInsets.symmetric(horizontal: 14, vertical: 5),
              decoration: BoxDecoration(
                color: whiteColor,
                borderRadius: BorderRadius.circular(14),
              ),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.center,
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
            )
          ],
        ),
      ),
    );
  }
}
