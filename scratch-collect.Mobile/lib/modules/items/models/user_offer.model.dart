import 'package:IB210370/modules/home/models/offer.model.dart';

class UserOffer {
  int? id;
  String? boughtOn;
  bool? played;
  String? playedOn;
  bool? won;
  int? userId;
  Offer? offer;

  UserOffer({
    this.id,
    this.boughtOn,
    this.played,
    this.playedOn,
    this.won,
    this.userId,
    this.offer,
  });

  UserOffer.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    boughtOn = json['boughtOn'];
    played = json['played'];
    playedOn = json['playedOn'];
    won = json['won'];
    userId = json['userId'];
    offer = json['offer'] != null ? Offer.fromJson(json['offer']) : null;
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};

    data['id'] = id;
    data['boughtOn'] = boughtOn;
    data['played'] = played;
    data['playedOn'] = playedOn;
    data['won'] = won;
    data['userId'] = userId;
    data['offer'] = offer;

    return data;
  }
}
