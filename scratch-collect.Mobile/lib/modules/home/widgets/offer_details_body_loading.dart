import 'package:flutter/widgets.dart';
import 'package:IB210370/modules/shared/theme/utils.dart';
import 'package:skeletons/skeletons.dart';

class OfferDetailsBodyLoading extends StatelessWidget {
  const OfferDetailsBodyLoading({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
        padding: const EdgeInsets.symmetric(vertical: 40, horizontal: 40),
        child: Column(
          children: <Widget>[
            SkeletonLine(
              style: SkeletonLineStyle(
                height: getProportionateScreenHeight(250),
              ),
            ),
            SizedBox(height: getProportionateScreenHeight(30)),
            SkeletonLine(
              style: SkeletonLineStyle(
                  height: getProportionateScreenHeight(30),
                  width: getProportionateScreenHeight(100)),
            ),
            SizedBox(height: getProportionateScreenHeight(20)),
            SkeletonLine(
              style: SkeletonLineStyle(
                height: getProportionateScreenHeight(30),
                width: getProportionateScreenHeight(160),
              ),
            ),
            SizedBox(height: getProportionateScreenHeight(45)),
            SkeletonLine(
              style: SkeletonLineStyle(
                height: getProportionateScreenHeight(60),
              ),
            ),
            SizedBox(height: getProportionateScreenHeight(60)),
            SkeletonLine(
              style: SkeletonLineStyle(
                height: getProportionateScreenHeight(30),
                width: getProportionateScreenWidth(100),
              ),
            ),
            SizedBox(height: getProportionateScreenHeight(35)),
            Row(
              children: <Widget>[
                SkeletonLine(
                  style: SkeletonLineStyle(
                    width: getProportionateScreenWidth(100),
                    height: getProportionateScreenHeight(100),
                  ),
                ),
                SizedBox(width: getProportionateScreenWidth(35)),
                SkeletonLine(
                  style: SkeletonLineStyle(
                    width: getProportionateScreenWidth(100),
                    height: getProportionateScreenHeight(100),
                  ),
                ),
              ],
            ),
          ],
        ));
  }
}
