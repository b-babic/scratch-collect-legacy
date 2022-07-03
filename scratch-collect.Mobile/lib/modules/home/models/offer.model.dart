import 'package:IB210370/modules/home/models/category.model.dart';

class Offer {
  int? id;
  String? title;
  String? description;
  int? quantity;
  int? requiredPrice;
  double? averageRating;
  String? createdAt;
  String? updatedAt;
  Category? category;
  List<Offer>? recommendedItems;

  Offer({
    this.id,
    this.title,
    this.description,
    this.quantity,
    this.requiredPrice,
    this.averageRating,
    this.createdAt,
    this.updatedAt,
    this.category,
    this.recommendedItems,
  });

  Offer.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    title = json['title'];
    description = json['description'];
    quantity = json['quantity'];
    requiredPrice = json['requiredPrice'];
    averageRating = json['averageRating'];
    createdAt = json['createdAt'];
    updatedAt = json['updatedAt'];
    category =
        json['category'] != null ? Category.fromJson(json['category']) : null;
    recommendedItems = json['recommendedItems'] != null
        ? Offer.listFromJson(json['recommendedItems'])
        : null;
  }

  static listFromJson(List<dynamic> list) {
    List<Offer> offers = [];

    for (var value in list) {
      offers.add(Offer.fromJson(value));
    }
    return offers;
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};

    data['id'] = id;
    data['title'] = title;
    data['description'] = description;
    data['quantity'] = quantity;
    data['requiredPrice'] = requiredPrice;
    data['averageRating'] = averageRating;
    data['createdAt'] = createdAt;
    data['updatedAt'] = updatedAt;
    data['category'] = category;

    return data;
  }
}
