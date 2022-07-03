import 'package:flutter/material.dart';
import 'package:IB210370/modules/items/models/user_offer.model.dart';
import 'package:IB210370/modules/shared/theme/colors.dart';

class WinningCard extends StatelessWidget {
  const WinningCard({
    Key? key,
    required this.winning,
    required this.keyPrefix,
  }) : super(key: key);

  final UserOffer winning;
  final String keyPrefix;

  DateTime getParsedDate() {
    return DateTime.parse(winning.playedOn ?? "");
  }

  @override
  Widget build(BuildContext context) {
    return ListTile(
      title: Row(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: <Widget>[
          Text(
            "${winning.offer?.title}",
            style: const TextStyle(
              fontWeight: FontWeight.w500,
            ),
          ),
          Text(
            "${winning.offer?.category?.name}",
            style: const TextStyle(
              color: primaryColor,
            ),
          )
        ],
      ),
      subtitle: Text(
        "${getParsedDate().year}-${getParsedDate().month}-${getParsedDate().day}",
      ),
    );
  }
}
