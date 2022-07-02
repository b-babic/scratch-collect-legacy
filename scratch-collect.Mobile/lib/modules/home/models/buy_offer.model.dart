import 'package:scratch_collect/modules/home/models/offer.model.dart';

class BuyOffer {
  int? id;
  bool? played;
  String? boughtOn;
  Offer? offer;

  BuyOffer({
    this.id,
    this.played,
    this.boughtOn,
    this.offer,
  });

  BuyOffer.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    played = json['played'];
    boughtOn = json['boughtOn'];
    offer = Offer.fromJson(json['offer']);
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};

    data['id'] = id;
    data['played'] = played;
    data['boughtOn'] = boughtOn;
    data['offer'] = offer;

    return data;
  }
}
