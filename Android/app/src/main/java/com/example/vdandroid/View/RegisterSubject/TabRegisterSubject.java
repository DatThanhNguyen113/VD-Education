package com.example.vdandroid.View.RegisterSubject;

import android.os.Bundle;
import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.support.v7.widget.GridLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.vdandroid.Adapter.RegisterSubjectAdapter;
import com.example.vdandroid.Model.RegisterSubjectModel;
import com.example.vdandroid.Presenter.RegisterSubjectTask;
import com.example.vdandroid.R;
import com.example.vdandroid.View.Interface.IViewRegisterSubject;

import java.util.ArrayList;
import java.util.List;

public class TabRegisterSubject extends Fragment {
    public static RecyclerView lvRegisterSubject;
    public static RegisterSubjectAdapter adapter;
//    public static RegisterSubjectModel model;
    public static List<RegisterSubjectModel> list;

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View view = inflater.inflate( R.layout.tab_register_subject, container, false);
        onInit(view);
        onGetListSubjects();
        return view;

    }

    public void onGetListSubjects(){
        new RegisterSubjectTask( getContext(), new IViewRegisterSubject() {
            @Override
            public void onGetSuccess() {
                adapter = new RegisterSubjectAdapter( getContext(), R.layout.item_register_subject, list);
                GridLayoutManager gridLayoutManager = new GridLayoutManager(getContext(), 1, GridLayoutManager.VERTICAL, false);
                lvRegisterSubject.setLayoutManager( gridLayoutManager );
                lvRegisterSubject.setAdapter( adapter );
                adapter.notifyDataSetChanged();
            }

            @Override
            public void onGetFail() {

            }
        } ).execute();


    }

    private void onInit(View view){
        lvRegisterSubject = view.findViewById( R.id.lvRegisterSubject );
    }
}
