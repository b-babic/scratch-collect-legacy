import 'package:IB210370/modules/home/widgets/rating_info.dart';
import 'package:flutter/material.dart';
import 'package:IB210370/modules/home/home.screen.dart';
import 'package:IB210370/modules/shared/theme/colors.dart';
import 'package:IB210370/modules/shared/theme/utils.dart';

class DetailsAppBar extends StatelessWidget {
  final double rating;

  const DetailsAppBar({super.key, required this.rating});

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
                  foregroundColor: primaryColor, shape: RoundedRectangleBorder(
                    borderRadius: BorderRadius.circular(60),
                  ),
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
            RatingInfo(
              rating: rating,
            ),
          ],
        ),
      ),
    );
  }
}
