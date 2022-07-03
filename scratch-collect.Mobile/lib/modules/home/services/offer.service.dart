import 'dart:convert';

import 'package:IB210370/modules/home/models/buy_offer.model.dart';
import 'package:IB210370/modules/home/models/offer.model.dart';
import 'package:IB210370/modules/home/models/offer_buy_request.model.dart';
import 'package:IB210370/modules/home/models/offer_details_request.model.dart';
import 'package:IB210370/modules/home/models/offer_search_request.model.dart';
import 'package:IB210370/modules/items/models/user_offer.model.dart';
import 'package:IB210370/modules/items/models/user_offer_play_request.model.dart';
import 'package:IB210370/modules/shared/utils/api/api.dart';

class OfferService {
  static OfferService? _instance;

  factory OfferService() => _instance ??= OfferService._();

  OfferService._();

  Future<List<Offer>> getOffers(OfferSearchRequest request) async {
    var category = request.categoryId;
    var query = request.query;
    String url = '/offer';

    if (category != null) {
      url = '$url?categoryId=$category';
    }

    if (category != null && query != null) {
      url = '$url&query=$query';
    } else if (category == null && query != null) {
      url = '$url?query=$query';
    }

    var response = await Api().dio.get(url);

    return List<Offer>.from(
      response.data.map(
        (model) => Offer.fromJson(model),
      ),
    );
  }

  Future<Offer> getOfferDetails(OfferDetailsRequest request) async {
    var id = request.id;

    var response = await Api().dio.get('/offer/$id');

    return Offer.fromJson(response.data);
  }

  // User's offers
  Future<BuyOffer> buyOffer(OfferBuyRequest request) async {
    var id = request.offerId;

    var response = await Api().dio.post(
          '/offer/buy/$id',
          data: jsonEncode(
            request.toJson(),
          ),
        );

    return BuyOffer.fromJson(response.data);
  }

  Future<List<UserOffer>> userOffers(OfferSearchRequest request) async {
    var userId = request.userId;

    var response = await Api().dio.post(
          '/user/$userId/offers',
          data: jsonEncode(
            request.toJson(),
          ),
        );

    return List<UserOffer>.from(
      response.data.map(
        (model) => UserOffer.fromJson(model),
      ),
    );
  }

  Future<List<UserOffer>> userWonOffers(OfferSearchRequest request) async {
    String url = '/user/won';

    var response = await Api().dio.post(
          url,
          data: jsonEncode(
            request.toJson(),
          ),
        );

    return List<UserOffer>.from(
      response.data.map(
        (model) => UserOffer.fromJson(model),
      ),
    );
  }

  Future<UserOffer> play(UserOfferPlayRequest request) async {
    var response = await Api().dio.post(
          '/offer/play',
          data: jsonEncode(
            request.toJson(),
          ),
        );

    return UserOffer.fromJson(response.data);
  }
}
