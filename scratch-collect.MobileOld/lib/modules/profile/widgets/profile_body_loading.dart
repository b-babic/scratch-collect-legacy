import 'package:flutter/widgets.dart';
import 'package:IB210370/modules/shared/theme/utils.dart';
// import 'package:skeletons/skeletons.dart';

class ProfileBodyLoading extends StatelessWidget {
  const ProfileBodyLoading({super.key});

  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
        padding: const EdgeInsets.symmetric(vertical: 40, horizontal: 40),
        child: Column(
          children: <Widget>[
            Column(
              mainAxisAlignment: MainAxisAlignment.center,
              crossAxisAlignment: CrossAxisAlignment.center,
              children: [
                // SkeletonAvatar(
                //   style: SkeletonAvatarStyle(
                //     height: getProportionateScreenHeight(250),
                //     width: getProportionateScreenWidth(250),
                //     shape: BoxShape.circle,
                //   ),
                // ),
                SizedBox(
                  height: getProportionateScreenHeight(15),
                ),
                // SkeletonLine(
                //   style: SkeletonLineStyle(
                //     height: getProportionateScreenHeight(30),
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
            SizedBox(height: getProportionateScreenHeight(30)),
            Row(
              mainAxisAlignment: MainAxisAlignment.center,
              children: <Widget>[
                // SkeletonLine(
                //   style: SkeletonLineStyle(
                //     width: getProportionateScreenHeight(60),
                //   ),
                // ),
                SizedBox(
                  width: getProportionateScreenWidth(45),
                ),
                // SkeletonLine(
                //   style: SkeletonLineStyle(
                //     width: getProportionateScreenHeight(60),
                //   ),
                // ),
              ],
            ),
            SizedBox(height: getProportionateScreenWidth(30)),
            // SkeletonLine(
            //   style: SkeletonLineStyle(
            //     height: getProportionateScreenHeight(60),
            //   ),
            // ),
            SizedBox(height: getProportionateScreenWidth(20)),
            // SkeletonLine(
            //   style: SkeletonLineStyle(
            //     height: getProportionateScreenHeight(60),
            //   ),
            // ),
            SizedBox(height: getProportionateScreenWidth(20)),
          ],
        ));
  }
}
