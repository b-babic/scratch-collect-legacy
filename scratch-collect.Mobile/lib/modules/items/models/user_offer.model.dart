import 'package:IB210370/modules/home/models/offer.model.dart';

class UserOffer {
  int? id;
  String? boughtOn;
  bool? played;
  String? playedOn;
  bool? won;
  int? userId;
  Offer? offer;
  double? averageRating;
  bool? alreadyRated;

  UserOffer({
    this.id,
    this.boughtOn,
    this.played,
    this.playedOn,
    this.won,
    this.userId,
    this.offer,
    this.averageRating,
    this.alreadyRated = false,
  });

  UserOffer.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    boughtOn = json['boughtOn'];
    played = json['played'];
    playedOn = json['playedOn'];
    won = json['won'];
    userId = json['userId'];
    offer = json['offer'] != null ? Offer.fromJson(json['offer']) : null;
    averageRating = json['averageRating'];
    alreadyRated = json['alreadyRated'];
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
    data['averageRating'] = averageRating;
    data['alreadyRated'] = alreadyRated;

    return data;
  }
}
