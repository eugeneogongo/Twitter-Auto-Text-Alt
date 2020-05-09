import { Component, OnInit } from "@angular/core";
import { PostServiceService } from "../post-service.service";
import { FormBuilder, FormGroup, FormControl, Validators } from "@angular/forms";

const URL = 'https://localhost:44334/extract';
@Component({
	selector: "pm-home",
	templateUrl: './home.component.html',
	styleUrls: ["./home.component.css"]
})
export class HomeComponent {
  Altext: string;
    imagePath: any;
  imgURL: string | ArrayBuffer;
  Loading: boolean = false;
	constructor(private uploadservice: PostServiceService) { }

	myForm = new FormGroup({

		file: new FormControl('', [Validators.required]),

		fileSource: new FormControl('', [Validators.required])

	});
	get f() {
		return this.myForm.controls;
	}
	onFileChange(event) {
    this.Altext = null;
		if (event.target.files.length > 0) {

			const file = event.target.files[0];

			this.myForm.patchValue({

				fileSource: file

      });
      this.Loading = true;
      this.setImage(event);
			this.submit();
		}

	}

  setImage(event:any) {
    var reader = new FileReader();
    this.imagePath = event.target.files;
    reader.readAsDataURL(event.target.files[0]);
    reader.onload = (_event) => {
      this.imgURL = reader.result;
    }

  }

	submit() {
		const formData = new FormData();
		formData.append('file', this.myForm.get('fileSource').value);
		this.uploadservice.GetAltText('https://localhost:44334/extract', formData)
			.subscribe(res => {
        this.Altext = res.text;
        this.Loading = false;
			})

	}
}
