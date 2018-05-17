function ViewModel() {
    self = this;
    self.contacts = ko.observableArray();
    self.contact = ko.observable();

    self.load = function () {
        $.ajax({
            url: "http://localhost:8088/webhost/api/contact",
            type: "GET",
            success: function (result) {
                self.contacts(result);
            }
        });
    };

    self.showDialog = function (data) {
        if (!data.Id) {
            data = { Id: "", Name: "", PhoneNo: "", EmailAddress: "", Address: "" }
        };
        self.contact(data);
        $(".modal").modal("show");
    };

    self.save = function () {
        $(".modal").modal('hide');
        if (self.contact().Id) {
            $.ajax({
                url: "http://localhost:8088/webhost/api/contact/" + self.contact.Id,
                type: "PUT",
                data: self.contact(),
                success: function () {
                    self.load();
                }
            });
        }
        else {
            $.ajax({
                url: "http://localhost:8088/webhost/api/contact",
                type: "POST",
                data: self.contact(),
                success: function () {
                    self.load();
                }
            });
        }
    };

    self.delete = function (data) {
        $.ajax({
            url: "http://localhost:8088/webhost/api/contact/" + data.Id,
            type: "DELETE",
            success: function () {
                self.load();
            }
        });
    };

    self.load();
};

$(function () {
    ko.applyBindings(new ViewModel());
})