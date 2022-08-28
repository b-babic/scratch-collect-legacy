import 'package:IB210370/modules/shared/theme/colors.dart';
import 'package:IB210370/modules/shared/theme/utils.dart';
import 'package:flutter/material.dart';
import 'package:flutter_rating_bar/flutter_rating_bar.dart';

class RatingDialogResponse {
  double rating;

  RatingDialogResponse({this.rating = 0.0});
}

class RatingDialog extends StatefulWidget {
  final Text title;
  final Text? message;
  final bool force;
  final bool showCloseButton;
  final bool isLoading;
  final double initialRating;
  final String submitButtonText;
  final Function(RatingDialogResponse) onSubmitted;
  final Function? onCancelled;

  const RatingDialog({
    Key? key,
    required this.title,
    this.message,
    required this.submitButtonText,
    required this.onSubmitted,
    this.isLoading = false,
    this.onCancelled,
    this.showCloseButton = true,
    this.force = false,
    this.initialRating = 0.0,
  }) : super(key: key);

  @override
  State<RatingDialog> createState() => _RatingDialogState();
}

class _RatingDialogState extends State<RatingDialog> {
  RatingDialogResponse? _response;

  @override
  void initState() {
    super.initState();
    _response = RatingDialogResponse(rating: widget.initialRating);
  }

  @override
  Widget build(BuildContext context) {
    final content = Stack(
      alignment: Alignment.topRight,
      children: <Widget>[
        ClipRRect(
          borderRadius: BorderRadius.circular(20.0),
          child: Padding(
            padding: const EdgeInsets.fromLTRB(25, 30, 25, 5),
            child: Column(
              mainAxisSize: MainAxisSize.min,
              crossAxisAlignment: CrossAxisAlignment.stretch,
              children: <Widget>[
                Container(),
                widget.title,
                SizedBox(height: getProportionateScreenHeight(10)),
                widget.message ?? Container(),
                SizedBox(height: getProportionateScreenHeight(20)),
                Center(
                  child: RatingBar.builder(
                    initialRating: widget.initialRating,
                    glowColor: amberColor,
                    minRating: 1,
                    itemSize: getProportionateScreenWidth(28),
                    direction: Axis.horizontal,
                    allowHalfRating: false,
                    itemCount: 5,
                    itemPadding: EdgeInsets.symmetric(
                      horizontal: getProportionateScreenWidth(4),
                    ),
                    onRatingUpdate: (rating) {
                      setState(() {
                        _response!.rating = rating;
                      });
                    },
                    itemBuilder: (context, _) => const Icon(
                      Icons.star,
                      color: amberColor,
                    ),
                  ),
                ),
                SizedBox(height: getProportionateScreenHeight(30)),
                TextButton(
                  onPressed: _response!.rating == 0
                      ? null
                      : () {
                          if (!widget.force) Navigator.pop(context);

                          widget.onSubmitted.call(_response!);

                          if (!widget.force && widget.onCancelled != null) {
                            widget.onCancelled!.call();
                          }
                        },
                  child: Text(
                    widget.submitButtonText,
                    style: TextStyle(
                      color: (_response!.rating == 0 || widget.isLoading)
                          ? tertiaryColor
                          : primaryColor,
                    ),
                  ),
                ),
              ],
            ),
          ),
        ),
        if (!widget.force &&
            widget.onCancelled != null &&
            widget.showCloseButton) ...[
          IconButton(
            icon: Icon(
              Icons.close,
              size: getProportionateScreenHeight(20),
            ),
            onPressed: () {
              Navigator.pop(context);
              widget.onCancelled!.call();
            },
          )
        ]
      ],
    );

    return AlertDialog(
      shape: RoundedRectangleBorder(
        borderRadius: BorderRadius.circular(
          getProportionateScreenHeight(15),
        ),
      ),
      titlePadding: EdgeInsets.zero,
      scrollable: true,
      title: content,
    );
  }
}
