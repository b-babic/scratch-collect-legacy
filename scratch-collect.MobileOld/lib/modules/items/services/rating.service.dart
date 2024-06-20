import 'dart:convert';

import 'package:IB210370/modules/items/models/rating.model.dart';
import 'package:IB210370/modules/items/models/rating_request.model.dart';
import 'package:IB210370/modules/shared/utils/api/api.dart';

class RatingService {
  static RatingService? _instance;

  factory RatingService() => _instance ??= RatingService._();

  RatingService._();

  Future<Rating> rate(RatingRequest request) async {
    var response = await Api().dio.post(
          '/offer/rate',
          data: jsonEncode(
            request.toJson(),
          ),
        );

    return Rating.fromJson(response.data);
  }
}
