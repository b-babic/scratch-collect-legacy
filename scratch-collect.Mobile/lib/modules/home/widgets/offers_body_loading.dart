import 'package:flutter/widgets.dart';
import 'package:IB210370/modules/shared/theme/utils.dart';
import 'package:skeletons/skeletons.dart';

// TODO: Add cusotm skeleton once UI is defined and ready (final design)
class OffersBodyLoading extends StatelessWidget {
  const OffersBodyLoading({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
        padding: const EdgeInsets.symmetric(vertical: 40, horizontal: 40),
        child: Column(
          children: <Widget>[
            Column(
              children: [
                SkeletonAvatar(
                  style: SkeletonAvatarStyle(
                    height: getProportionateScreenHeight(250),
                    width: getProportionateScreenWidth(250),
                    shape: BoxShape.circle,
                  ),
                )
              ],
            ),
            const SizedBox(height: 30),
            SkeletonLine(
                style: SkeletonLineStyle(
                    height: getProportionateScreenHeight(40))),
            const SizedBox(height: 30),
            SkeletonLine(
                style: SkeletonLineStyle(
                    height: getProportionateScreenHeight(60))),
            const SizedBox(height: 20),
            SkeletonLine(
                style: SkeletonLineStyle(
                    height: getProportionateScreenHeight(60))),
            const SizedBox(height: 20),
            SkeletonLine(
                style: SkeletonLineStyle(
                    height: getProportionateScreenHeight(60))),
            const SizedBox(height: 20),
          ],
        ));
  }
}
