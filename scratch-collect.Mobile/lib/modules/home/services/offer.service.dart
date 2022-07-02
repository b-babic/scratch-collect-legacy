import 'package:scratch_collect/modules/home/models/offer.model.dart';
import 'package:scratch_collect/modules/home/models/offer_search_request.model.dart';
import 'package:scratch_collect/modules/shared/utils/api/api.dart';

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
}
