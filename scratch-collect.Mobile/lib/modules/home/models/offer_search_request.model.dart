class OfferSearchRequest {
  String? query;
  int? categoryId;

  OfferSearchRequest({
    this.query,
    this.categoryId,
  });

  OfferSearchRequest.fromJson(Map<String, dynamic> json) {
    query = json['query'];
    categoryId = json['categoryId'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};

    data['query'] = query;
    data['categoryId'] = categoryId;

    return data;
  }
}
