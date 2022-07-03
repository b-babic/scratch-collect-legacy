import 'package:flutter/widgets.dart';
import 'package:IB210370/modules/shared/theme/utils.dart';

class DetailsInfo extends StatelessWidget {
  final String? title;
  final String? description;

  const DetailsInfo({
    Key? key,
    required this.title,
    required this.description,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: <Widget>[
        Text(
          "$title",
          style: TextStyle(
            fontSize: getProportionateScreenWidth(20),
            fontWeight: FontWeight.bold,
          ),
        ),
        SizedBox(height: getProportionateScreenHeight(15)),
        Text(
          "$description",
          style: TextStyle(
            fontSize: getProportionateScreenWidth(16),
            fontWeight: FontWeight.normal,
          ),
        ),
      ],
    );
  }
}
