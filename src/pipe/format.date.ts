import { Pipe, PipeTransform } from '@angular/core';
@Pipe({ name: 'formatDate' })
export class FormatDatePipe implements PipeTransform {

    transform(value: string) {
        let date = new Date(value);
        return `Ngay ${date.getDate()} thang ${date.getMonth()} nam ${date.getFullYear()}`;
    }
}