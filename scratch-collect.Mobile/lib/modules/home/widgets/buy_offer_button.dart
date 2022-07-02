import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:scratch_collect/modules/home/home.screen.dart';
import 'package:scratch_collect/modules/home/models/offer_buy_request.model.dart';
import 'package:scratch_collect/modules/home/services/offer.service.dart';
import 'package:scratch_collect/modules/home/widgets/offer_button_info.dart';
import 'package:scratch_collect/modules/profile/models/profile.model.dart';
import 'package:scratch_collect/modules/profile/services/profile.service.dart';
import 'package:scratch_collect/modules/shared/widgets/button.dart';
import 'package:scratch_collect/modules/shared/widgets/snackbar.dart';

class BuyOfferButton extends StatefulWidget {
  final int? offerId;
  final int? requiredPrice;

  const BuyOfferButton({
    Key? key,
    required this.offerId,
    required this.requiredPrice,
  }) : super(key: key);

  @override
  BuyOfferButtonState createState() => BuyOfferButtonState();
}

class BuyOfferButtonState extends State<BuyOfferButton> {
  late final ProfileResponse? user;
  bool canBuy = false;

  int? get offerId => widget.offerId;
  int? get requiredPrice => widget.requiredPrice ?? 0;
  int? get walletBalance => user != null ? user?.wallet?.balance.toInt() : 0;

  @override
  void initState() {
    super.initState();

    ProfileService().getPersistedProfile().then((value) {
      setState(() {
        user = value;
        canBuy = walletBalance! - requiredPrice! >= 0;
      });
    }).catchError((err) {
      Snackbar.showError(context, err.toString());
    });
  }

// TODO Get initial user object initially and handle disabled states if enough money ?
// Handle on press to buy item and redirect back or to bought items screen ?

  @override
  Widget build(BuildContext context) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: <Widget>[
        Button(
          text: "Buy this offer",
          disabled: !canBuy,
          press: () async {
            try {
              var request = OfferBuyRequest(
                userId: user?.id,
                offerId: offerId,
              );

              var response = await OfferService().buyOffer(request);

              if (!mounted) return;

              if (response.offer != null) {
                Snackbar.showSuccess(context, "Successfully bought offer!");

                // If we bought the last item, move back to the offers screen
                if (response.offer?.quantity == 0) {
                  Navigator.pushReplacement(
                    context,
                    MaterialPageRoute(
                      builder: (context) => const HomeScreen(),
                    ),
                  );
                }
              } else {
                Snackbar.showError(context, "Something went wrong!");
              }
            } on Exception catch (e) {
              Snackbar.showError(context, e.toString());
            }
          },
        ),
        if (!canBuy) const OfferButtonInfo(),
      ],
    );
  }
}
