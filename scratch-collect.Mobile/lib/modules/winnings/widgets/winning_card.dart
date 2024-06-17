import 'package:flutter/material.dart';
import 'package:IB210370/modules/items/models/user_offer.model.dart';
import 'package:IB210370/modules/shared/theme/colors.dart';

class WinningCard extends StatelessWidget {
  const WinningCard({
    super.key,
    required this.winning,
    required this.keyPrefix,
  });

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
          Expanded(
            child: Text(
              "${winning.offer?.title}",
              maxLines: 1,
              overflow: TextOverflow.ellipsis,
              style: const TextStyle(
                fontWeight: FontWeight.w500,
              ),
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
