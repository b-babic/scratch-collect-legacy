class OfferBuyRequest {
  int? userId;
  int? offerId;

  OfferBuyRequest({
    this.userId,
    this.offerId,
  });

  OfferBuyRequest.fromJson(Map<String, dynamic> json) {
    userId = json['userId'];
    offerId = json['offerId'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};

    data['userId'] = userId;
    data['offerId'] = offerId;

    return data;
  }
}
