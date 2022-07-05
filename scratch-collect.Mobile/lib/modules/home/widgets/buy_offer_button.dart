import 'package:IB210370/modules/home/details.screen.dart';
import 'package:flutter/material.dart';
import 'package:IB210370/modules/home/home.screen.dart';
import 'package:IB210370/modules/home/models/offer_buy_request.model.dart';
import 'package:IB210370/modules/home/services/offer.service.dart';
import 'package:IB210370/modules/home/widgets/offer_button_info.dart';
import 'package:IB210370/modules/profile/models/profile.model.dart';
import 'package:IB210370/modules/profile/services/profile.service.dart';
import 'package:IB210370/modules/shared/widgets/button.dart';
import 'package:IB210370/modules/shared/widgets/snackbar.dart';

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
  bool isLoading = false;

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

  void toggleLoading() {
    setState(() {
      isLoading = !isLoading;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: <Widget>[
        Button(
          disabled: !canBuy || isLoading,
          loading: isLoading,
          text: "Buy this offer",
          press: () async {
            toggleLoading();

            try {
              var request = OfferBuyRequest(
                userId: user?.id,
                offerId: offerId,
              );

              var response = await OfferService().buyOffer(request);

              if (!mounted) return;

              if (response.offer != null) {
                Snackbar.showSuccess(context, "Successfully bought offer!");

                Navigator.pushReplacement(
                  context,
                  MaterialPageRoute(
                    builder: (context) => const HomeScreen(),
                  ),
                );
              } else {
                Snackbar.showError(context, "Something went wrong!");
              }
            } on Exception catch (e) {
              Snackbar.showError(context, e.toString());
            } finally {
              toggleLoading();
            }
          },
        ),
        if (!canBuy) const OfferButtonInfo(),
      ],
    );
  }
}
