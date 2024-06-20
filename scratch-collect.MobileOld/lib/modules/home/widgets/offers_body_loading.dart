import 'package:flutter/widgets.dart';
import 'package:IB210370/modules/shared/theme/utils.dart';
// import 'package:skeletons/skeletons.dart';

class OffersBodyLoading extends StatelessWidget {
  const OffersBodyLoading({super.key});

  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
        padding: const EdgeInsets.symmetric(vertical: 40, horizontal: 40),
        child: Column(
          children: <Widget>[
            SizedBox(height: getProportionateScreenHeight(60)),
            Column(
              children: [
                // SkeletonLine(
                //   style: SkeletonLineStyle(
                //     height: getProportionateScreenHeight(40),
                //     width: getProportionateScreenWidth(200),
                //   ),
                // ),
                SizedBox(height: getProportionateScreenHeight(15)),
                // SkeletonLine(
                //   style: SkeletonLineStyle(
                //     height: getProportionateScreenHeight(40),
                //     width: getProportionateScreenWidth(400),
                //   ),
                // ),
              ],
            ),
            SizedBox(height: getProportionateScreenHeight(60)),
            Row(
              children: <Widget>[
                // SkeletonLine(
                //   style: SkeletonLineStyle(
                //     height: getProportionateScreenHeight(40),
                //     width: getProportionateScreenWidth(60),
                //   ),
                // ),
                SizedBox(width: getProportionateScreenHeight(15)),
                // SkeletonLine(
                //   style: SkeletonLineStyle(
                //     height: getProportionateScreenHeight(40),
                //     width: getProportionateScreenWidth(60),
                //   ),
                // ),
                SizedBox(width: getProportionateScreenHeight(15)),
                // SkeletonLine(
                //   style: SkeletonLineStyle(
                //     height: getProportionateScreenHeight(40),
                //     width: getProportionateScreenWidth(60),
                //   ),
                // ),
              ],
            ),
            SizedBox(height: getProportionateScreenHeight(30)),
            // SkeletonLine(
            //   style: SkeletonLineStyle(
            //     height: getProportionateScreenHeight(60),
            //   ),
            // ),
            SizedBox(height: getProportionateScreenHeight(60)),
            // SkeletonLine(
            //   style: SkeletonLineStyle(
            //     height: getProportionateScreenHeight(200),
            //   ),
            // ),
          ],
        ));
  }
}
