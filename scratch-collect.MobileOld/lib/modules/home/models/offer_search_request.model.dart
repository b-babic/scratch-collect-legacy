class OfferSearchRequest {
  int? userId;
  String? query;
  int? categoryId;

  OfferSearchRequest({
    this.userId,
    this.query,
    this.categoryId,
  });

  OfferSearchRequest.fromJson(Map<String, dynamic> json) {
    userId = json['userId'];
    query = json['query'];
    categoryId = json['categoryId'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};

    data['userId'] = userId;
    data['query'] = query;
    data['categoryId'] = categoryId;

    return data;
  }
}
