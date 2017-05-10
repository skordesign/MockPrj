import { Component, OnInit, Input, Pipe, PipeTransform, AfterViewInit, EventEmitter, Output, OnChanges, AfterViewChecked, ViewChild } from '@angular/core';
import { UserMngtService } from '../../../../services/usermngt.service';
import { ToasterService } from 'angular2-toaster';
@Component({
    selector: 'user-detail',
    templateUrl: './userdetail.component.html',
    styleUrls: ['./userdetail.component.css']
})

export class UserDetailComponent implements OnInit, AfterViewInit, OnChanges {

    ngOnChanges(changes: any): void {
        this.getRole(this.user.roleId);
        if (typeof window !== "undefined") {
            $(document).ready(function () {
                $('.mdb-select').material_select('destroy');
                $('.mdb-select').material_select();
            });
        }
    }
    @Input()
    user: any;
    @Input() isView: boolean
    @Input() isAdd: boolean

    @Output() outputEvent: EventEmitter<string> = new EventEmitter();

    optionsRole: any[];
    selectedRole: any;

    constructor(private userService: UserMngtService, private toaster: ToasterService) { }
    ngOnInit(): void {
        // this.getRole(this.user.roleId);
        this.getRoles();
    }
    ngAfterViewInit(): void {
        this.getRole(this.user.roleId);
    }
    getRoles() {
        this.userService.getRoles().subscribe(result => {
            this.optionsRole = result;
        },
            error => this.toaster.popAsync("error", "Error", "System has problem."));
    }

    getRole(roleId: number) {
        this.userService.getRole(roleId).subscribe(result => {
            this.selectedRole = result;
        },
            error => this.toaster.popAsync("error", "Error", "System has problem."));
    }
    saveChanges() {
        if ($('#roleSelector').val() != null) {
            this.user.roleId = $('#roleSelector').val();
        }
        if (this.isAdd) {
            this.userService.add(this.user).subscribe(result => {
                if (result) {
                    this.outputEvent.emit();
                }
            });
        } else {
            this.userService.edit(this.user).subscribe(result => {
            });
        }
    }
}
