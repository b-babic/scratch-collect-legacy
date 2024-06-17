import 'dart:async';

import 'package:flutter/material.dart';
import 'package:IB210370/modules/home/services/offer.service.dart';
import 'package:IB210370/modules/items/items.screen.dart';
import 'package:IB210370/modules/items/models/play_screen_arguments.model.dart';
import 'package:IB210370/modules/items/models/user_offer_play_request.model.dart';
import 'package:IB210370/modules/items/utils/probability.dart';
import 'package:IB210370/modules/shared/theme/utils.dart';
import 'package:IB210370/modules/shared/widgets/button.dart';
import 'package:IB210370/modules/shared/widgets/snackbar.dart';

class PlayBody extends StatefulWidget {
  final PlayScreenArguments args;

  const PlayBody({super.key, required this.args});

  @override
  State<PlayBody> createState() => _PlayBodyState();
}

class _PlayBodyState extends State<PlayBody> {
  late Timer _timer;
  int _start = 3;
  bool scratchStarted = false;

  void startTimer() {
    const oneSec = Duration(seconds: 1);

    _timer = Timer.periodic(
      oneSec,
      (Timer timer) {
        if (_start == 0) {
          setState(() {
            timer.cancel();
          });

          initiateScratchSequence(context);
        } else {
          setState(() {
            _start--;
          });
        }
      },
    );
  }

  Future<void> initiateScratchSequence(BuildContext context) async {
    setState(() {
      scratchStarted = true;
    });

    try {
      var won = await calculateWonProbability(widget.args.requiredPrice);

      var request = UserOfferPlayRequest(
        widget.args.userOfferId,
        widget.args.offerId,
        won,
      );

      var response = await OfferService().play(request);
      if (!mounted) return;

      await showRevealDialog(context, response.won ?? false);
    } on Exception catch (e) {
      Snackbar.showError(context, e.toString());
    }
  }

  Future<void> showRevealDialog(BuildContext context, bool success) async {
    return success
        ? showDialog(
            context: context,
            builder: (BuildContext context) {
              return AlertDialog(
                title: const Text('Congrats!'),
                content: const Text('You\'ve won.'),
                actions: <Widget>[
                  Button(
                    text: 'Ok',
                    press: () {
                      Navigator.pushReplacement(
                        context,
                        MaterialPageRoute(
                          builder: (context) => const ItemsScreen(),
                        ),
                      );
                    },
                  ),
                ],
              );
            },
          )
        : showDialog(
            context: context,
            builder: (BuildContext context) {
              return AlertDialog(
                title: const Text('Oh, that\'s sad!'),
                content: const Text('More luck next time.'),
                actions: <Widget>[
                  Button(
                    text: 'Ok',
                    press: () {
                      Navigator.pushReplacement(
                        context,
                        MaterialPageRoute(
                          builder: (context) => const ItemsScreen(),
                        ),
                      );
                    },
                  ),
                ],
              );
            },
          );
  }

  @override
  void initState() {
    super.initState();
    startTimer();
  }

  @override
  void dispose() {
    _timer.cancel();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Container(
        alignment: Alignment.center,
        padding: const EdgeInsets.symmetric(horizontal: 20, vertical: 20),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget>[
            if (!scratchStarted)
              Text(
                "Scratching your card",
                style: TextStyle(
                  fontSize: getProportionateScreenWidth(24),
                  fontWeight: FontWeight.bold,
                ),
              ),
            if (scratchStarted)
              Text(
                "One moment please",
                style: TextStyle(
                  fontSize: getProportionateScreenWidth(24),
                  fontWeight: FontWeight.bold,
                ),
              ),
            SizedBox(height: getProportionateScreenHeight(15)),
            if (!scratchStarted)
              Text(
                "in $_start...",
                style: TextStyle(
                  fontSize: getProportionateScreenWidth(20),
                ),
              ),
            if (scratchStarted)
              Text(
                "We are updating your wins...",
                style: TextStyle(
                  fontSize: getProportionateScreenWidth(20),
                ),
              ),
          ],
        ),
      ),
    );
  }
}
