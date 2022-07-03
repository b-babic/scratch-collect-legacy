import 'package:IB210370/modules/home/models/category.model.dart';

class Offer {
  int? id;
  String? title;
  String? description;
  int? quantity;
  int? requiredPrice;
  String? createdAt;
  String? updatedAt;
  Category? category;

  Offer({
    this.id,
    this.title,
    this.description,
    this.quantity,
    this.requiredPrice,
    this.createdAt,
    this.updatedAt,
    this.category,
  });

  Offer.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    title = json['title'];
    description = json['description'];
    quantity = json['quantity'];
    requiredPrice = json['requiredPrice'];
    createdAt = json['createdAt'];
    updatedAt = json['updatedAt'];
    category =
        json['category'] != null ? Category.fromJson(json['category']) : null;
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};

    data['id'] = id;
    data['title'] = title;
    data['description'] = description;
    data['quantity'] = quantity;
    data['requiredPrice'] = requiredPrice;
    data['createdAt'] = createdAt;
    data['updatedAt'] = updatedAt;
    data['category'] = category;

    return data;
  }
}
